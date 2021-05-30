using System;
using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }


    // GetProfilesKeeps getting the keeps by the profiles ID
    // This is coming from profiles controller
    public List<Keep> GetProfilesKeeps(string id)
    {
      return _repo.GetProfilesKeeps(id);
    }
    // CreateKeep
    public Keep Create(Keep newKeep)
    {
      // TODO B Logic so you can only create if youre logged in

      return _repo.Create(newKeep);
    }
    // ----------------------------------------------------********************




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