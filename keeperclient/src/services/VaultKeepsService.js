import { vaultsService } from '../services/VaultsService'
import { api } from './AxiosService'

class VaultKeepsService {
  async moveToVault(newVaultKeep) {
    await api.post('api/vaultkeeps', newVaultKeep)
    // console.log(res.data)
  }

  async deleteOneKeepFromVault(vkId, vaultId) {
    // await keepsService.getById(vaultId)
    const res = await api.delete(`api/vaultkeeps/${vkId}`)
    vaultsService.GetVaultsKeeps(vaultId)
    console.log(res.data)
  }
}

export const vaultKeepsService = new VaultKeepsService()
