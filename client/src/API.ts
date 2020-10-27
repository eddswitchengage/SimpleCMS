import { SimpleAPIClient, SearchQuery, Topic, Category } from "./models";
import Axios from "axios";

const BaseURL = "https://localhost:44348/api/";

/*
    SimpleCMS API Integration Module
*/

const addDaysToDate = (date: Date, days: number) => {
  const result = new Date(date);
  result.setDate(result.getDate() + days);
  return result;
};

const APIClient: SimpleAPIClient = {
  content: {
    getAll: async (query: SearchQuery) => {
      const createdAfterDate = query.filters.createdWithinDays
        ? addDaysToDate(new Date(), query.filters.createdWithinDays)
        : new Date(-1);
      const modifiedAfterDate = query.filters.updatedWithinDays
        ? addDaysToDate(new Date(), query.filters.updatedWithinDays)
        : new Date(-1);

      const uri =
        BaseURL +
        `contents/getall?searchTerm=${query.searchTerm}&topicId=${
          query.filters.topicId
        }
        &categoryId=${
          query.filters.categoryId
        }&createdAfter=${createdAfterDate.toISOString()}&modifiedAfter=${modifiedAfterDate.toISOString()}
        &pageIndex=${query.pageIndex}&pageSize=${query.pageSize}`;

      try {
        const result = await Axios.get(uri);
        return result.data.contents;
      } catch (error) {
        console.log(`An error occurred trying to retrieve content: ${error}`);
        return [];
      }
    },
    getById: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    upsert: async (topic: Topic) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    delete: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
  },

  topics: {
    getById: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    getAll: async () => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    upsert: async (topic: Topic) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    delete: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
  },
  categories: {
    getById: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    getAll: async () => {
      const uri = BaseURL + "categories/getall";
      try {
        const result = await Axios.get(uri);
        return result.data.categories;
      } catch (error) {
        console.log(
          `An error occurred trying to retrieve categories: ${error}`
        );
        return {};
      }
    },
    upsert: async (topic: Topic) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
    delete: async (id: number) => {
      console.log("NOT YET IMPLEMENTED hehe");
    },
  },
};

export default APIClient;
