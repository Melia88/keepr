using System;
using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    private readonly VaultsRepository _vrepo;

    public KeepsService(KeepsRepository repo, VaultsRepository vrepo)
    {
      _repo = repo;
      _vrepo = vrepo;
    }


    // GetProfilesKeeps getting the keeps by the profiles ID
    // This is coming from profiles controller
    public List<Keep> GetProfilesKeeps(string userId)
    {
      return _repo.GetProfilesKeeps(userId);
    }
    // CreateKeep
    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
    // ----------------------------------------------------********************
    public List<VaultKeepsViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      // I need to get the vault thats holding the keeps
      var vault = _vrepo.GetVaultById(vaultId);
      // then I need to check if its private or not
      if (vault.CreatorId == userId | vault.IsPrivate == false)
      {
        return _repo.GetKeepsByVaultId(vaultId);
        // not private or it is the creator return the vaultkeep

      }
      else
      {
        throw new Exception("You are NOT the creator");
      }
      // if its private throw an error
    }

    // GetAll
    internal List<Keep> GetAll()
    {
      return _repo.GetAll();
    }


    // GetKeepById
    internal Keep GetKeepById(int id)
    {
      Keep keep = _repo.GetKeepById(id);
      if (keep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      return keep;
    }


    // UpdateKeep
    internal Keep Update(Keep update, string id)
    {
      // first we get the keep
      Keep keep = _repo.GetKeepById(update.Id);
      if (keep == null)
      {
        throw new Exception("ID does not exist!");
      }
      // check if update.creatorId is the same as original.creator id
      if (update.CreatorId != keep.CreatorId)
      {
        throw new Exception("You cant do that!");
      }
      keep.Name = update.Name.Length > 0 ? update.Name : keep.Name;
      keep.Description = update.Description != null ? update.Description : keep.Description;
      keep.Img = update.Img != null ? update.Img : keep.Img;
      keep.Views = update.Views > 0 ? update.Views : keep.Views;
      keep.Shares = update.Shares > 0 ? update.Shares : keep.Shares;
      keep.Keeps = update.Keeps > 0 ? update.Keeps : keep.Keeps;
      return _repo.Update(keep);


    }

    // RemoveKeep
    internal void Remove(int id, string userId)
    {
      // Business Logic
      Keep keep = _repo.GetKeepById(id);

      if (keep.CreatorId != userId)
      {
        throw new Exception("No, no, no this isn't yours!");
      }
      _repo.Remove(id);
    }
  }
}