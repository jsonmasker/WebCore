import { EUrl } from './app/core/common/url-api';
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7185';


const context = Object.values(EUrl);

const PROXY_CONFIG = [
  {
    context,
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
