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


    // GetProfilesKeeps
    // This is coming from profiles controller
    internal List<VaultKeepsViewModel> GetProfilesKeeps(int id)
    {
      throw new NotImplementedException();
    }


    // CreateKeep


    // GetKeepById


    // UpdateKeep


    // RemoveKeep

  }
}