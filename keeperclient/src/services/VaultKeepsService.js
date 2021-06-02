import { api } from './AxiosService'

class VaultKeepsService {
  async moveToVault(newVaultKeep) {
    await api.post('api/vaultkeeps', newVaultKeep)
    // console.log(res.data)
  }
}

export const vaultKeepsService = new VaultKeepsService()
