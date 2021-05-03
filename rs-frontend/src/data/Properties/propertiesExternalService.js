import axios from 'axios';

class PropertiesExternalService {
  constructor(config) {
    this.serviceUrl = config.propertiesAPI;

    this.axiosClient = axios.create({
      baseURL: this.serviceUrl,
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
      },
    });
  }

  retrievePropertiesList() {
    return this.axiosClient
      .get()
      .catch((error) => {
        return Promise.reject(error);
      });
  }

}

export default PropertiesExternalService;
