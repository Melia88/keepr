import { AppState } from '../AppState'
import router from '../router.js'
import { api } from './AxiosService'

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
    // await profileDetailsService(userId)
    router.push({ name: 'ProfileDetailsPage' })
  }

  async GetVaultsKeeps(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.vaultKeeps = res.data
    console.log(res.data)
  }
}
export const vaultsService = new VaultsService()
