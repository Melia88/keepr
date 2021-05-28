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

    internal void Remove(int id)
    {
      throw new NotImplementedException();
    }

    internal Vault Create(Vault vault)
    {
      throw new NotImplementedException();
    }

    internal Vault GetVaultById(int id)
    {
      throw new NotImplementedException();
    }

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


    // CreateVault


    // GetVaultById


    // UpdateVault


    // RemoveVault

  }
}