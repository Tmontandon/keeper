import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Keep.js').Keep} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep} */
  selectedKeep: {},
  /** @type {import('./models/Vault.js').Vault} */
  selectedVault: {},
  /** @type {import('./models/Account.js').Account} */
  profile: {},
  /** @type {import('./models/Keep.js').Keep} */
  accountKeeps: [],
  /** @type {import('./models/Vault.js').Vault} */
  accountVaults: []


})
