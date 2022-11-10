import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { router } from "../router.js"
import Pop from "../utils/Pop.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async postVault(vData) {
    const res = await api.post("/api/vaults", vData)
    AppState.accountVaults.push(new Vault(res.data))
  }

  async deleteVault(vId) {
    await api.delete(`/api/vaults/${vId}`)
    AppState.accountVaults = AppState.accountVaults.filter(v => v.id != vId)
  }

  async getSelectedVault(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.selectedVault = new Vault(res.data)
    // AppState.account = await api.get('/account')
    if (AppState.selectedVault.isPrivate && AppState.selectedVault.creatorId != AppState.account.id) {
      router.push({ name: 'Home' })
      Pop.toast('you are very much not allowed to see private vaults >:(')
      AppState.selectedVault = {}
    }
  }
  async getVaultKeeps(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    // console.log("getting vault keeps", res.data);
    AppState.keeps = res.data.map((k) => new Keep(k))
    // AppState.keeps = res.data
  }


}

export const vaultsService = new VaultsService()