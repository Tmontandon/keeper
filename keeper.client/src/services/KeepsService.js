import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getAllKeeps() {
    const res = await api.get("/api/keeps")
    AppState.keeps = res.data.map((k) => new Keep(k))
  }

  async postKeep(keepData) {
    const res = await api.post("/api/keeps", keepData)
    const keep = new Keep(res.data)
    AppState.keeps = [...AppState.keeps, keep]
  }

  async viewKeep(id) {
    await api.get(`api/keeps/${id}`)
  }

}

export const keepsService = new KeepsService()