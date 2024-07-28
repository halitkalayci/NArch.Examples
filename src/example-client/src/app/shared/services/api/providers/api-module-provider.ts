import { importProvidersFrom } from '@angular/core';
import { ApiModule } from '../api.module';
import { Configuration, ConfigurationParameters } from '../configuration';

export function apiConfigFactory(): Configuration {
  const params: ConfigurationParameters = {
    basePath: 'http://localhost:60805',
    withCredentials: true,
  };
  return new Configuration(params);
}

export function provideAPIServices() {
  return importProvidersFrom(ApiModule.forRoot(() => apiConfigFactory()));
}
