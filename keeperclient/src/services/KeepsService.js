import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
    // console.log(res.data)
  }

  // GETBYID
  async createKeep(body) {
    await api.post('api/keeps', body)

    body.keeps += 1
  }
}
export const keepsService = new KeepsService()
