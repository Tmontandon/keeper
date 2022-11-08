import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async postVault(vData) {
    const res = await api.post("/api/vaults", vData)
    console.log(res.data);
  }

}

export const vaultsService = new VaultsService()