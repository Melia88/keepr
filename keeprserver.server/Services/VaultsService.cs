using System;
using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    private readonly KeepsRepository _krepo;
    private readonly VaultKeepsRepository _vkrepo;

    public VaultsService(VaultsRepository repo, KeepsRepository krepo, VaultKeepsRepository vkrepo)
    {
      _repo = repo;
      _krepo = krepo;
      _vkrepo = vkrepo;
    }

    // CreateVault
    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }



    //TODO GetProfilesVaults
    // This is coming from profiles controller
    public IEnumerable<Vault> GetProfilesVaults(string id)
    {
      return _repo.GetProfilesVaults(id);
    }
    // GetAll
    internal List<Vault> GetAll()
    {
      return _repo.GetAll();
    }


    // GetVaultById
    internal Vault GetVaultById(int id)
    {
      Vault vault = _repo.GetVaultById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      else if (vault.IsPrivate == true)
      {
        throw new Exception("Private Vault, Only Creater Has Access!");
      }
      return vault;
    }

    // GetVaultById security check
    internal Vault GetVaultById(int id, string userId)
    {
      Vault vault = _repo.GetVaultById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      else if (vault.IsPrivate == true && vault.CreatorId != userId)
      {
        throw new Exception("Not Yours!");
      }
      return vault;
    }

    // UpdateVault
    internal Vault Update(Vault update)
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
    public IEnumerable<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      Vault vault = _repo.GetVaultById(vaultId);
      if (vault.CreatorId != userId)
      {
        throw new Exception("Not Yours!");
      }

      return _krepo.GetKeepsByVaultId(vaultId);
    }
  }
}