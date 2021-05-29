using System;
using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public List<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId);
    }
    // Create 
    public VaultKeeps CreateVaultKeeps(VaultKeeps vk)
    {
      return _repo.CreateVaultKeeps(vk);
    }

    // Delete
    public void Remove(int id, string userId)
    {
      VaultKeeps vk = Get
      if ( .CreatorId != userId)
      {
        throw new Exception("Cannot Delete");
      }
      return _repo.Remove();
    }






    // GetKeepsByVaultId
    // public IEnumerable<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId, string userId)
    // {
    //   Vault vault = _repo.GetVaultById(vaultId);
    //   if (vault.CreatorId != userId)
    //   {
    //     throw new Exception("Not Yours!");
    //   }

    //   return _vkrepo.GetKeepsByVaultId(vaultId);
    // }
  }
}