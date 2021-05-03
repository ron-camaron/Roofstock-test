import axios from "axios";

class PropertiesService {
  constructor(config) {
    this.serviceUrl = config.rsApi;

    this.axiosClient = axios.create({
      baseURL: this.serviceUrl,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
    });
  }

  saveOrUpdateProperty(
    id,
    address1,
    address2,
    city,
    state,
    zipCode,
    zipPlus4,
    yearBuilt,
    listPrice,
    monthlyRent
  ) {
    let propertyData = {
      id,
      address1,
      address2,
      city,
      state,
      zip: zipCode,
      zipPlus4,
      yearBuilt,
      listPrice,
      monthlyRent,
    };

    return this.axiosClient
      .post("Property/SaveOrUpdate", propertyData)
      .catch((error) => {
        return Promise.reject(error);
      });
  }
}

export default PropertiesService;
