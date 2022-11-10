import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getAllKeeps() {
    const res = await api.get("/api/keeps")
    // console.log("bruh", res.data);
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

  async deleteKeep(id) {
    await api.delete(`/api/keeps/${id}`)
    AppState.accountKeeps = AppState.accountKeeps.filter((k) => k.id != id)
  }

  async unvaultKeep(vaultKeepId, keepId) {
    await api.delete(`/api/vaultkeeps/${vaultKeepId}`)
    // console.log("beofre", AppState.keeps);
    AppState.keeps = AppState.keeps.filter(k => k.id !== keepId)
    // console.log("after", AppState.keeps);
    AppState.selectedKeep = {}
  }

  async vaultKeep(vaultId, keepId) {
    const body = { vaultId, keepId }
    await api.post(`/api/vaultkeeps`, body)
  }
}

export const keepsService = new KeepsService()