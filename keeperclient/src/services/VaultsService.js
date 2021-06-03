import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileDetailsService } from './ProfileDetailsService'

class VaultsService {
  async createVault(body) {
    const res = await api.post('api/vaults', body)
    // this.getVaultById(body.id)
    body.vaults += 1
    AppState.profileVaults.push(res.data)
    // console.log(body)
  }

  // GetAllVaults
  // ??
  // GETBYID
  async getVaultById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.activeVault = res.data
    console.log(res.data)
  }

  async deleteVault(id, userId) {
    await api.delete(`api/vaults/${id}`)
    await profileDetailsService(userId)
  }

  async GetVaultsKeeps(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.vaultKeeps = res.data
  }
}
export const vaultsService = new VaultsService()
