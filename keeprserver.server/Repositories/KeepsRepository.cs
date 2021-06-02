using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeprserver.server.Models;

namespace keeprserver.server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // GetProfilesKeeps
    public List<Keep> GetProfilesKeeps(string id)
    {
      string sql = @"
      SELECT
        k.*,
        k.id as keepsId,
        p.*
      FROM
        keeps k
      JOIN profiles p ON p.id = k.creatorId
      WHERE
        k.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, new { id }).ToList();
    }

    //TODO CreateKeep
    public Keep Create(Keep newKeep)
    {
      string sql = @"
                INSERT INTO 
                keeps(creatorId, name, description, img)
                VALUES (@CreatorId, @Name, @Description, @Img);
                SELECT LAST_INSERT_ID();
            ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }
    // -------------------------------------------------------
    // public Keep Create(Keep newKeep)
    // {
    //   string sql = @"
    //             INSERT INTO 
    //             vaults(creatorId, name, description, img, views, shares, keeps)
    //             VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
    //             SELECT LAST_INSERT_ID();
    //         ";
    //   newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
    //   return newKeep;
    // }
    // IN GetAll I need to "populate" the creators info so I get all from k & p
    public List<Keep> GetAll()
    {
      string sql = @"
      SELECT 
        k.*,
        p.*
      FROM keeps k
      JOIN profiles p ON k.creatorId = p.id;  
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, splitOn: "id").ToList();
    }

    // internal List<VaultKeepsViewModel> GetKeepsByVaultId(int id)
    // {
    //   string sql = @"
    //             SELECT 
    //             k.*,
    //             vk.id AS VaultKeepsId
    //             FROM vault_keeps vk
    //             INNER JOIN keeps k ON k.id = vk.keepsId
    //             WHERE vaultId = @VaultId AND isPrivate = 0";
    //   return _db.Query<VaultKeepsViewModel>(sql, new { id }).ToList();

    // }
    internal List<VaultKeepsViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
                SELECT 
                k.*,
                v.*,
                p.*,
                vk.vaultId as vaultId,
                vk.id AS VaultKeepsId
                FROM vault_keeps vk
                JOIN keeps k ON k.id = vk.keepsId
                JOIN vaults v ON v.id = vk.vaultId
                JOIN profiles p ON k.id = p.id
                WHERE vk.id = @id ";
      return _db.Query<VaultKeepsViewModel>(sql, new { id }).ToList();

    }
    // AND isPrivate = 0
    // -------------------------------------------------------


    //TODO GetKeepById
    public Keep GetKeepById(int id)
    {
      string sql = @"
      SELECT 
        k.*,
        p.*
      From keeps k
      JOIN profiles p ON p.id = k.creatorId
      WHERE k.id = @id;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, new { id }).FirstOrDefault();
    }

    //TODO UpdateKeep
    public Keep Update(Keep original)
    {
      string sql = @"
            UPDATE keeps 
            SET 
                name = @Name,
                description = @Description,
                img = @Img,
                views = @Views,
                shares = @Shares,
                keeps = @Keeps
            WHERE id = @Id;
            ";
      _db.Execute(sql, original);
      return original;
    }

    //TODO RemoveKeep
    public void Remove(int id)
    {
      string sql = @"
      DELETE FROM keeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}