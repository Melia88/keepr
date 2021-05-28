using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeprserver.server.Models;

namespace keeprserver.server.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    // Get all keeps that belong to one vault

    internal List<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT
        k.*,
        v.id as vaultId,
        p.id as = creatorId,
        p.name as = creatorsName,
        vk.Id as vaultKeepsId,
        vk.vaultId as vaultId,
        vk.keepsId as keepsId
      FROM
        vault_keeps vk
      JOIN vaults v ON v.id = vk.vaultId
      JOIN keeps k ON k.id = vk.keepsId
      JOIN profiles p ON p.id = vk.profilesId
      WHERE
        vk.vaultId = @id;";
      return _db.Query<VaultKeepsViewModel>(sql, new { vaultId }).ToList();
    }


    internal List<VaultKeepsViewModel> GetProfilesKeeps(int vaultId)
    {
      string sql = @"
      SELECT
        k.*,
        v.name as vaultName,
        v.description as vaultsDescription,
        v.creatorId as creatorId,
        vk.Id as vaultKeepsId,
        vk.vaultId as vaultId,
        vk.keepsId as keepsId
      FROM
        vault_keeps vk
      JOIN vaults v ON v.id = vk.vaultId
      JOIN keeps k ON k.id = vk.keepsId
      WHERE
        vk.creatorId = @id;";
      return _db.Query<VaultKeepsViewModel>(sql, new { vaultId }).ToList();
    }
  }
}