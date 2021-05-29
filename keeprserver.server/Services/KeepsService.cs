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
    internal IEnumerable<Keep> GetProfilesKeeps(string id)
    {
      return _repo.GetProfilesKeeps(id);
    }

    internal Keep Create(Keep newKeep)
    {

      return _repo.Create(newKeep);
    }


    // CreateKeep


    // GetKeepById


    // UpdateKeep


    // RemoveKeep

  }
}