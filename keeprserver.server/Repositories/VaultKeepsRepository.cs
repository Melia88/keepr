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

    public List<VaultKeepsViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT
        k.*,
        v.name as vaultName,
        vk.id as vaultKeepsId,
        vk.vaultId as vaultId,
        vk.keepsId as keepsId
        vk.creatorId as creatorId
      FROM
        vault_keeps vk
      JOIN vaults v ON v.id = vk.vaultId
      JOIN keeps k ON k.id = vk.keepsId
      JOIN profiles p ON p.id = k.creatorId
      WHERE
        vk.vaultId = @id;";
      return _db.Query<VaultKeepsViewModel, Profile, VaultKeepsViewModel>(sql, (vk, p) =>
      {
        vk.Creator = p;
        return vk;
      }, new { id }).ToList();
    }

    // GetVaultKeep
    public VaultKeepsViewModel GetVaultKeepById(int id)
    {
      string sql = @"
      SELECT 
      vk.id as vaultKeepsId,
      vk.vaultId as vaultId,
      vk.keepsId as keepsId,
      k.*,
      p.*
      FROM vault_keeps vk
      JOIN keeps k ON k.id = vk.keepsId
      JOIN profiles p ON p.id = vk.creatorId
      WHERE vk.id = @id;
      ";
      return _db.Query<VaultKeepsViewModel, Profile, VaultKeepsViewModel>(sql, (vk, p) =>
     {
       vk.Creator = p;
       return vk;
     }, new { id }).FirstOrDefault();
    }
    // // ADDED !!!!!!!!
    // internal VaultKeeps Get(int id)
    // {
    //   string sql = "SELECT * FROM vault_keeps WHERE id = @id";
    //   return _db.QueryFirstOrDefault<VaultKeeps>(sql, new { id });
    // }

    public VaultKeeps CreateVaultKeeps(VaultKeeps vk)
    {
      string sql = @"
      UPDATE keeps 
      SET 
      keeps = keeps + 1 
      WHERE id = @keepsId; 
      INSERT INTO 
            vault_keeps
            (creatorId, vaultId, keepsId)
            VALUES 
            (@CreatorId, @VaultId, @KeepsId);
            SELECT LAST_INSERT_ID();
            ";

      vk.Id = _db.ExecuteScalar<int>(sql, vk);
      return vk;
    }

    // public void Remove(int id)
    // {
    //   string sql = @"
    //   DELETE FROM vault_keeps WHERE id = @id LIMIT 1;
    //   ";
    //   _db.Execute(sql, new { id });
    // }
    internal void Remove(int id)
    {
      string sql = "DELETE FROM vault_keeps WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });

    }
  }
}