using Marten;
using Marten.Services;
using MartenExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Data
{
    public class MartenProvider
    {

        private DocumentStore _store { get; }

        public MartenProvider(string connectionString)
        {
            _store = DocumentStore.For(x =>
            {
                x.Connection(connectionString);
                x.Serializer(new JsonNetSerializer { EnumStorage = EnumStorage.AsInteger });

                x.Schema.For<Customer>().Duplicate(y => y.Id, configure: y => y.IsUnique = true);

                x.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
            });
        }

        public FunctionResponse<bool> SaveUser(HMUser user)
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                if (user.Id == default(Guid) || user.Id == null)
                {
                    user.Id = Guid.NewGuid();
                }

                using (var session = _store.LightweightSession())
                {
                    session.Store(user);
                    session.SaveChanges();
                }

                resp.SetToSuccess(true);

            }
            catch (Exception ex)
            {
                resp.SetToError(ex);
                
            }
            return resp;
        }

        public FunctionResponse<HMUser> GetUser(string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<HMUser> resp = new FunctionResponse<HMUser>();

            try
            {
                if (userId != null || id != default(Guid))
                {
                    using (var session = _store.QuerySession())
                    {
                        HMUser existing;

                        if (userId != null)
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.UserId == userId)
                                        .Single();
                        }
                        else
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.Id == id)
                                        .Single();
                        }

                        resp.SetToSuccess(existing);
                    }
                }
                else
                {
                    //Edge case condition, no parameters passed in.
                    resp.SetToError("No Valid parameter passed in");
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);                
            }

            return resp;
        }

        public FunctionResponse<Asset> GetAsset(Guid assetId)
        {
            FunctionResponse<Asset> resp = new FunctionResponse<Asset>();

            try
            {

                using (var session = _store.QuerySession())
                {
                    Asset existing;
                    existing = session.Query<Asset>().Where(x => x.Id == assetId).Single();

                    if (existing != null)
                    {
                        resp.SetToSuccess(existing);
                    }
                    else
                    {
                        resp.SetToError("No asset element found");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);                
            }

            return resp;
        }

        public FunctionResponse<UpKeep> GetUpkeep(Guid upkeepId, Guid assetId)
        {
            FunctionResponse<UpKeep> resp = new FunctionResponse<UpKeep>();

            try
            {

                using (var session = _store.QuerySession())
                {
                    UpKeep existing;
                    existing = session.Query<Asset>().Where(x => x.Id == assetId).FirstOrDefault()
                                                    ?.UpKeeps.Where(y => y.Id == upkeepId).FirstOrDefault();

                    if (existing != null)
                    {
                        resp.SetToSuccess(existing);
                    }
                    else
                    {
                        resp.SetToError("No Upkeep element found");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);                
            }

            return resp;
        }

        public FunctionResponse<bool> AddAssetToUser(Asset asset, string userId = null, Guid id = default(Guid))
        {

            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                if (userId != null || id != default(Guid))
                {
                    HMUser existing;

                    using (var session = _store.LightweightSession())
                    {
                        if (userId != null)
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.UserId == userId)
                                        .Single();
                        }
                        else
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.Id == id)
                                        .Single();
                        }

                        asset.HMUserAuthId = existing.UserId;
                        asset.HMUserId = existing.Id;

                        existing.UpsertAssetLite(asset.ToLite());

                        session.Update<HMUser>(existing);
                        session.Store<Asset>(asset);
                        session.SaveChanges();
                        resp.SetToSuccess(true);
                    }
                }
                else
                {
                    //Edge case condition, no parameters passed in.
                    resp.SetToError("No Valid parameter passed in");
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);                
            }

            return resp;

        }

        public FunctionResponse<bool> RemoveAssetFromUser(Guid assetId, string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                if (userId != null || id != default(Guid))
                {

                    HMUser existing;
                    using (var session = _store.LightweightSession())
                    {

                        //Remove the lite item
                        if (userId != null)
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.UserId == userId)
                                        .Single();

                        }
                        else
                        {
                            existing = session.Query<HMUser>()
                                        .Where(x => x.Id == id)
                                        .Single();

                        }

                        if (existing != null)
                        {
                            AssetLite remAsset = existing.AssetsLite.Where(x => x.Id == assetId).FirstOrDefault();
                            existing.AssetsLite.Remove(remAsset);

                            //Remove the asset row
                            session.DeleteWhere<Asset>(x => x.Id == assetId);

                            session.Update<HMUser>(existing);

                            session.SaveChanges();
                            resp.SetToSuccess(true);
                        }
                        else
                        {
                            resp.SetToError("User not found");
                        }
                    }
                }
                else
                {
                    //Edge case condition, no parameters passed in.
                    resp.SetToError("No Valid parameter passed in");
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);
            }

            return resp;
        }

        public FunctionResponse<bool> AddUpKeepToAsset(UpKeep upkeep, Guid assetId, string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                Asset existingAsset;
                HMUser existingUser;
                using (var session = _store.LightweightSession())
                {

                    if (userId != null)
                    {
                        existingUser = session.Query<HMUser>()
                                    .Where(x => x.UserId == userId)
                                    .Single();
                    }
                    else
                    {
                        existingUser = session.Query<HMUser>()
                                    .Where(x => x.Id == id)
                                    .Single();
                    }

                    existingAsset = session.Query<Asset>()
                                .Where(x => x.Id == assetId && x.HMUserId == existingUser.Id)
                                .Single();

                    if (existingAsset != null)
                    {

                        existingAsset.UpKeeps.Add(upkeep);
                        existingUser.UpsertAssetLite(existingAsset.ToLite());

                        session.Update<Asset>(existingAsset);
                        session.Update<HMUser>(existingUser);

                        session.SaveChanges();
                        resp.SetToSuccess(true);
                    }
                    else
                    {
                        resp.SetToError("Asset not found");
                    }
                }
            }

            catch (Exception ex)
            {
                resp.SetToError(ex);
            }

            return resp;
        }

        public FunctionResponse<bool> RemoveUpkeepFromAsset(Guid upkeepId, Guid assetId, string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                Asset existingAsset;
                HMUser existingUser;
                using (var session = _store.LightweightSession())
                {
                    if (userId != null)
                    {
                        existingUser = session.Query<HMUser>()
                                    .Where(x => x.UserId == userId)
                                    .Single();
                    }
                    else
                    {
                        existingUser = session.Query<HMUser>()
                                    .Where(x => x.Id == id)
                                    .Single();
                    }

                    existingAsset = session.Query<Asset>()
                                .Where(x => x.Id == assetId)
                                .Single();

                    if (existingAsset != null)
                    {
                        UpKeep remUpkeep = existingAsset.UpKeeps.Where(x => x.Id == upkeepId).FirstOrDefault();
                        existingAsset.UpKeeps.Remove(remUpkeep);

                        foreach(AssetLite ass in existingUser.AssetsLite)
                        {
                            if(ass.Id == existingAsset.Id)
                            {
                                ass.UpKeepCount = existingAsset.UpKeeps.Count;
                                break;
                            }
                        }

                        session.Update<Asset>(existingAsset);
                        session.Update<HMUser>(existingUser);

                        session.SaveChanges();
                        resp.SetToSuccess(true);
                    }
                    else
                    {
                        resp.SetToError("Asset not found");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);
            }

            return resp;
        }

        public FunctionResponse<bool> UpdateAssetDetails(string name, string notes, DateTime ownedDate, AssetType type, Guid assetId, string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                Asset existing;
                using (var session = _store.LightweightSession())
                {

                    existing = session.Query<Asset>()
                                .Where(x => x.Id == assetId)
                                .Single();

                    if (existing != null)
                    {
                        if (existing.HMUserAuthId == userId || existing.HMUserId == id)
                        {
                            existing.Name = name;
                            existing.Notes = notes;
                            existing.OwnedDate = ownedDate;
                            existing.TypeOfAsset = type;
                            existing.UpdatedDate = DateTime.Now;

                            session.Update<Asset>(existing);
                            session.SaveChanges();
                            resp.SetToSuccess(true);
                        }
                        else
                        {
                            resp.SetToError("User does not have access to asset");
                        }
                    }
                    else
                    {
                        resp.SetToError("Asset not found");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);
            }

            return resp;
        }

        public FunctionResponse<bool> UpdateUpkeepDetails(string description, TimeSpan freq, string name, string notes, UpKeepSeverity severity, Guid assetId, Guid upkeepId, string userId = null, Guid id = default(Guid))
        {
            FunctionResponse<bool> resp = new FunctionResponse<bool>();

            try
            {
                Asset existing;
                using (var session = _store.LightweightSession())
                {

                    existing = session.Query<Asset>()
                                .Where(x => x.Id == assetId)
                                .Single();

                    if (existing != null)
                    {
                        if (existing.HMUserAuthId == userId || existing.HMUserId == id)
                        {
                            foreach (UpKeep up in existing.UpKeeps)
                            {
                                if (up.Id == upkeepId)
                                {
                                    up.Description = description;
                                    up.Frequency = freq;
                                    up.Name = name;
                                    up.Notes = notes;
                                    up.Severity = severity;
                                    break;
                                }
                            }

                            session.Update<Asset>(existing);

                            session.SaveChanges();
                            resp.SetToSuccess(true);
                        }
                        else
                        {
                            resp.SetToError("Do not have access to this asset");
                        }
                    }
                    else
                    {
                        resp.SetToError("Asset not found");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.SetToError(ex);
            }

            return resp;
        }

    }
}
