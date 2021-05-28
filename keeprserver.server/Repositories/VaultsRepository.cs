using System;
using System.Data;
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



    // CreateVault


    // GetVaultById


    // UpdateVault


    // RemoveVault

  }
}