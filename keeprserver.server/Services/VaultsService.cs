using System;
using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    private readonly VaultKeepsRepository _vkrepo;

    public VaultsService(VaultsRepository repo, VaultKeepsRepository vkrepo)
    {
      _repo = repo;
      _vkrepo = vkrepo;
    }

    // CreateVault
    internal Vault Create(Vault vault)
    {
      return _repo.Create(vault);
    }



    //TODO GetProfilesVaults
    // This is coming from profiles controller
    public List<Vault> GetProfilesVaults(int vaultId)
    {
      return _repo.GetProfilesVaults(vaultId);
    }

    // GetVaultById
    internal Vault GetVaultById(int id)
    {
      Vault vault = _repo.GetVaultById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      return vault;
    }

    // UpdateVault
    internal Vault Update(Vault update, string id)
    {
      // first we get the vault
      Vault original = GetVaultById(update.Id);
      // check if update.creatorId is the same as original.creator id
      if (update.CreatorId != original.CreatorId)
      {
        throw new Exception("You cant do that!");
      }

      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Description = update.Description.Length > 0 ? update.Description : original.Description;
      original.IsPrivate = update.IsPrivate ? update.IsPrivate : original.IsPrivate;
      if (_repo.Update(original))
      {
        return original;
      }
      throw new Exception("Something went wrong??");
    }

    // RemoveVault
    internal void Remove(int id, string userId)
    {
      // Business Logic
      // REVIEW notice I can re-use my own coolness
      Vault vault = GetVaultById(id);

      if (vault.CreatorId != userId)
      {
        throw new Exception("No, no, no this isn't yours!");
      }
      _repo.Remove(id);
    }
    // GetKeepsByVaultId
    // public List<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId)
    // {
    //   return _vkrepo.GetKeepsByVaultId(vaultId);
    // }
  }
}