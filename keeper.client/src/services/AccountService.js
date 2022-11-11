import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Keep } from '../models/Keep.js'
import { Vault } from '../models/Vault.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  //#region Account Reqs
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getAccountVaults() {
    try {
      const res = await api.get(`/account/vaults`)
      AppState.accountVaults = res.data.map((v) => new Vault(v))
    } catch (error) {
      logger.log(error)
    }
  }

  async editAccount(data) {
    try {
      const res = await api.put(`/account`, data)
      AppState.account = new Account(res.data)
    } catch (error) {
      logger.log(error)
    }
  }
  //#endregion 

  //#region Profile Reqs
  async getUserKeeps(id) {
    try {
      const res = await api.get(`api/profiles/${id}/keeps`)
      AppState.accountKeeps = res.data.map((k) => new Keep(k))
    } catch (error) {
      logger.log(error)
    }
  }

  async getUser(id) {
    try {
      const res = await api.get(`api/profiles/${id}`)
      AppState.profile = new Account(res.data)
    } catch (error) {
      logger.log(error)
    }
  }

  async getUserVaults(id) {
    try {
      const res = await api.get(`api/profiles/${id}/vaults`)
      AppState.accountVaults = res.data.map((v) => new Vault(v))
    } catch (error) {
      logger.log(error)
    }
  }

  //#endregion
}

export const accountService = new AccountService()
