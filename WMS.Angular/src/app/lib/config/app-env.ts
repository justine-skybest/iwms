/** Dev environment for every app; production builds swap in `app-env.prod.ts` via `fileReplacements`. */
export const environment = {
  production: false,
  apiUrl: "http://localhost:8805",
  signalrHubUrl: "http://localhost:8805/hubs/notifications",
  identityServerUrl: "http://localhost:7001",
};