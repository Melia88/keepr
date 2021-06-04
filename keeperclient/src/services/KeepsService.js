import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
    // console.log(res.data)
  }

  // GETBYID
  async getById(id) {
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
    console.log(res.data)
  }

  async createKeep(body) {
    await api.post('api/keeps', body)
    // console.log(res.data)
    body.keeps += 1
  }

  async deleteKeep(id) {
    await api.delete(`api/keeps/${id}`)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }
}
export const keepsService = new KeepsService()
