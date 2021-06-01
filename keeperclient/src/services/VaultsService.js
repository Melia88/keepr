import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async createVault(body) {
    const res = await api.post('api/vaults', body)
    // this.getVaultById(body.id)
    // body.vaults += 1
    console.log(res.data)
  }

  // GETBYID
  async getVaultById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.vaults = res.data
    // console.log(res.data)
  }
}
export const vaultsService = new VaultsService()
