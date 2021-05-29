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
    internal List<Vault> GetProfilesVaults(int vaultId)
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
      JOIN vaults v ON v.id = vk.vaultId
      JOIN profiles p ON p.id = vk.creatorId
      WHERE
        vk.creatorId = @id;";
      return _db.Query<Vault>(sql, new { vaultId }).ToList();
    }

  }
}