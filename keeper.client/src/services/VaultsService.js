import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async postVault(vData) {
    await api.post("/api/vaults", vData)
  }

}

export const vaultsService = new VaultsService()