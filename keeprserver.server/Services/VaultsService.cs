using System;
using System.Collections.Generic;
using System.Linq;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    private readonly KeepsRepository _krepo;
    private readonly VaultsRepository _vrepo;
    private readonly VaultKeepsRepository _vkrepo;

    public VaultsService(VaultsRepository repo, KeepsRepository krepo, VaultsRepository vrepo, VaultKeepsRepository vkrepo)
    {
      _repo = repo;
      _krepo = krepo;
      _vrepo = vrepo;
      _vkrepo = vkrepo;
    }


    // CreateVault
    internal Vault Create(Vault newVault)
    {
      // TODO B Logic so you can only create if youre logged in
      return _repo.Create(newVault);
    }

    // ADDED !!!!!!!!
    internal IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }



    // TODO GetProfilesVaults
    // This is coming from profiles controller
    public List<Vault> GetVaultsByProfileId(string id)
    {
      List<Vault> vaults = _repo.GetVaultsByProfileId(id);
      return vaults.ToList().FindAll(v => v.IsPrivate == false);

    }
    // GetAll
    internal List<Vault> GetAll()
    {
      return _repo.GetAll();
    }


    // GetVaultById
    // internal Vault GetVaultById(int id)
    // {
    //   Vault vault = _repo.GetVaultById(id);
    //   if (vault == null)
    //   {
    //     throw new Exception("Invalid Vault Id");
    //   }
    //   else if (vault.IsPrivate == true)
    //   {
    //     throw new Exception("Private Vault, Only Creater Has Access!");
    //   }
    //   return vault;
    // }

    // GetVaultById security check
    public Vault GetVaultById(int id, string userId)
    {
      Vault vault = _repo.GetVaultById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      // else if (vault.IsPrivate == true && vault.CreatorId != userId)
      // {
      //   throw new Exception("Private Vault, Only Creater Has Access!");
      // }
      // if (vault.IsPrivate == true && vault.CreatorId == userId)
      // {
      //   return vault;
      // }
      else if (vault.CreatorId == userId || vault.IsPrivate == false)
      {
        return vault;
      }
      else
      {
        throw new Exception("You are NOT the creator");
      }
    }

    // public Vault GetPublicVaultById(int id)
    // {

    //   Vault publicVault = _repo.GetPublicVaultById(id);
    //   if (publicVault == null)
    //   {
    //     throw new Exception("Invalid Vault Id");
    //   }
    //   return publicVault;
    // }

    // UpdateVault
    // internal Vault Update(Vault update, string userId)
    // {
    //   // first we get the vault
    //   Vault original =  _vrepo.GetVaultById(update.Id);
    //   // check if update.creatorId is the same as original.creator id
    //   if (update.CreatorId != original.CreatorId)
    //   {
    //     throw new Exception("You cant do that!");
    //   }

    //   original.Name = update.Name.Length > 0 ? update.Name : original.Name;
    //   original.Description = update.Description.Length > 0 ? update.Description : original.Description;
    //   original.IsPrivate = update.IsPrivate ? update.IsPrivate : original.IsPrivate;
    //   if (_repo.Update(original))
    //   {
    //     return original;
    //   }
    //   throw new Exception("Something went wrong??");
    // }
    internal Vault Update(Vault update, string id)
    {
      // first we get the vault
      Vault vault = _vrepo.GetVaultById(update.Id);
      if (vault == null)
      {
        throw new Exception("ID does not exist!");
      }
      // check if update.creatorId is the same as original.creator id
      if (update.CreatorId != vault.CreatorId)
      {
        throw new Exception("You cant do that!");
      }
      vault.Name = update.Name.Length > 0 ? update.Name : vault.Name;
      vault.Description = update.Description != null ? update.Description : vault.Description;
      vault.IsPrivate = update.IsPrivate != update.IsPrivate ? update.IsPrivate : vault.IsPrivate;
      return _repo.Update(vault);

      throw new Exception("Something went wrong??");
    }


    // RemoveVault
    internal void Remove(int id, string userId)
    {
      // Business Logic
      // REVIEW notice I can re-use my own coolness
      Vault vault = _vrepo.GetVaultById(id);

      if (vault.CreatorId != userId)
      {
        throw new Exception("No, no, no this isn't yours!");
      }
      _repo.Remove(id);
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