import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getAllKeeps() {
    const res = await api.get("/api/keeps")
    AppState.keeps = res.data.map((k) => new Keep(k))
  }

  showNewKeepModal() {
    const myModal = new bootstrap.Modal('#keepModal', {
      keyboard: false
    })
    myModal.show()
  }

}

export const keepsService = new KeepsService()