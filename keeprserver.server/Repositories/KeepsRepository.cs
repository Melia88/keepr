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
    internal IEnumerable<Keep> GetProfilesKeeps(string id)
    {
      string sql = @"
      SELECT
        k.*,
        k.name as keepName,
        k.creatorId as creatorId,
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
      }, new { id });
    }

    //TODO CreateKeep
    // internal Keep Create(Keep newKeep)
    // {
    //   string sql = @"
    //             INSERT INTO 
    //             keeps(creatorId, name, description, img, views, shares, keeps)
    //             VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
    //             SELECT LAST_INSERT_ID();
    //         ";
    //   newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
    //   return newKeep;
    // }
    // -------------------------------------------------------
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
                INSERT INTO 
                vaults(creatorId, name, description, img, views, shares, keeps)
                VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
                SELECT LAST_INSERT_ID();
            ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }

    // -------------------------------------------------------


    //TODO GetKeepById


    //TODO UpdateKeep


    //TODO RemoveKeep
  }
}