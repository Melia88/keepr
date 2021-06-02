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

    // public List<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId, string userId)
    // {
    //   return _repo.GetKeepsByVaultId(vaultId);
    // }
    // // Create 
    // public VaultKeeps CreateVaultKeeps(VaultKeeps vk)
    // {
    //   // if (vk.CreatorId != userId)
    //   // {
    //   //   throw new Exception("Cannot do that");
    //   // }
    //   // Keep vk = _repo.
    //   return _repo.CreateVaultKeeps(vk);
    // }

    public VaultKeeps CreateVaultKeeps(VaultKeeps vk)
    {
      // Keep vk = _repo.
      return _repo.CreateVaultKeeps(vk);
    }


    // ADDED !!!!!!!!
    // Delete
    public void Remove(int id, string userId)
    {
      VaultKeepsViewModel found = _repo.GetVaultKeepById(id);
      if (found.CreatorId != userId)
      {
        throw new Exception("Invalid Request");
      }
      _repo.Remove(id);

    }




    // ----------------------------------------------------------------------**********************

    // // GetVaultKeepById
    // public VaultKeepsViewModel GetVaultKeepById(int id, string userId)
    // {
    //   VaultKeepsViewModel vk = _repo.GetVaultKeepById(id);
    //   if (vk == null)
    //   {
    //     throw new Exception("Invalid ID");
    //   }
    //   else if (vk.CreatorId == userId | vk.IsPrivate == false)
    //   {
    //     return vk;
    //   }
    //   else
    //   {
    //     throw new Exception("Vault keep is private");
    //   }
    // }
  }
}