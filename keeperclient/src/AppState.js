import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  profile: {},
  activeProfile: {},
  keeps: [],
  vaults: [],
  vaultKeeps: [],
  activeKeep: {},
  activeVault: [],
  privateVaults: [],
  profileKeeps: [],
  profileVaults: [],
  isPrivate: false
})
