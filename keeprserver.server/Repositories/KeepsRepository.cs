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
    internal List<Keep> GetProfilesKeeps(int vaultId)
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
      return _db.Query<Keep>(sql, new { vaultId }).ToList();
    }

    //TODO CreateKeep
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
                INSERT INTO 
                keeps(creatorId, name, description, img, views, shares, keeps)
                VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
                SELECT LAST_INSERT_ID();
            ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }

    //TODO GetKeepById


    //TODO UpdateKeep


    //TODO RemoveKeep
  }
}