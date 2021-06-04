using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeprserver.server.Models;

namespace keeprserver.server.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    // CreateVault
    internal Vault Create(Vault newVault)
    {
      string sql = @"
                INSERT INTO vaults
                (creatorId, name, description, isPrivate, img)
                VALUES 
                (@CreatorId, @Name, @Description, @IsPrivate, @Img);
                SELECT LAST_INSERT_ID();
            ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal IEnumerable<Vault> Get()
    {
      string sql = "SELECT * FROM vaults";
      return _db.Query<Vault>(sql);
    }


    // GetVaultById
    // internal Vault GetPublicVaultById(int id)
    // {
    //   string sql = @"
    //   SELECT 
    //     v.*,
    //     p.*
    //   FROM vaults v
    //   JOIN profiles p ON p.id = v.creatorId
    //   WHERE v.id = @Id AND v.isPrivate = 0;";
    //   // return _db.QueryFirstOrDefault<Vault>(sql, new { Id = id });

    //   return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
    //   {
    //     v.Creator = p;
    //     return v;
    //   }, new { id }).FirstOrDefault();
    // }
    internal Vault GetVaultById(int id)
    {
      string sql = @"
      SELECT 
        v.*,
        p.*
      FROM vaults v
      JOIN profiles p ON p.id = v.creatorId
      WHERE v.id = @id";
      // return _db.QueryFirstOrDefault<Vault>(sql, new { Id = id });

      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, new { id }).FirstOrDefault();
    }

    internal List<Vault> GetAll()
    {
      string sql = @"
      SELECT 
        v.*,
        p.*
      FROM vaults v
      JOIN profiles p ON p.id = v.creatorId;  
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }).ToList();
    }

    //TODO UpdateVault
    internal Vault Update(Vault original)
    {
      string sql = @"
            UPDATE vaults 
            SET 
                creatorId = @CreatorId,
                name = @Name,
                description = @Description,
                isPrivate = @IsPrivate
            WHERE id = @Id;
            ";
      _db.Execute(sql, original);
      return original;
      // int affectedRows = 
      // return affectedRows == 1;
    }

    // GetProfilesVaults
    // Get all vaults that belong to one profile. THis is a get by creatorId

    // ----------------------------------------------------
    internal List<Vault> GetVaultsByProfileId(string id)
    {
      string sql = @"
      SELECT 
      v.*,
      p.*
      FROM vaults v
      JOIN profiles p ON v.creatorId = p.id
      WHERE v.creatorId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, new { id }, splitOn: "id").ToList();
    }


    // ----------------------------------------------------
    // getMyVaults


    // RemoveVault
    internal void Remove(int id)
    {
      string sql = @"
      DELETE FROM vaults WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    // return _db.Query<Vault, Profile, Vault>(sql, new { vaultId }).ToList();
    // {
    //   v.Creator = p;
    //   return v;
    // }, new { id }).FirstOrDefault();
  }
}