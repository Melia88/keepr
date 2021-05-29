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
    // RemoveVault
    internal void Remove(int id)
    {
      throw new NotImplementedException();
    }
    // CreateVault
    internal Vault Create(Vault newVault)
    {
      string sql = @"
                INSERT INTO 
                vaults(creatorId, name, description, isPrivate)
                VALUES (@CreatorId, @Name, @Description, @IsPrivate);
                SELECT LAST_INSERT_ID();
            ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }
    // GetVaultById
    internal Vault GetVaultById(int id)
    {
      throw new NotImplementedException();
    }
    // UpdateVault
    internal bool Update(Vault original)
    {
      throw new NotImplementedException();
    }

    // GetProfilesVaults
    // Get all vaults that belong to one profile
    internal IEnumerable<Vault> GetProfilesVaults(string id)
    {
      string sql = @"
      SELECT
        v.*,
        v.name as vaultName,
        v.description as vaultsDescription,
        v.creatorId as creatorId,
        p.*
      FROM
        vaults v
      JOIN profiles p ON p.id = v.creatorId
      WHERE
        v.creatorId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, new { id });
    }
    // return _db.Query<Vault, Profile, Vault>(sql, new { vaultId }).ToList();
    // {
    //   v.Creator = p;
    //   return v;
    // }, new { id }).FirstOrDefault();
  }
}