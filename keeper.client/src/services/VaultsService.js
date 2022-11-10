import { AppState } from "../AppState.js"
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
    AppState.vaults = AppState.vaults.filter(v => v.id != vId)
  }

  async getSelectedVault(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.selectedVault = new Vault(res.data)
    if (AppState.selectedVault.isPrivate && AppState.selectedVault.creatorId != AppState.account.id) {
      router.push({ name: 'Home' })
      Pop.toast('you are very much not allowed to see private vaults >:(')
      AppState.selectedVault = {}
    }


  }
}

export const vaultsService = new VaultsService()