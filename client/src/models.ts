export interface Content {
  id: number;
  topicId: number;
  title: string;
  description: string;
  htmlBody: string;
  tags: string;
}

export interface Topic {
  id: number;
  categoryId: number;
  title: string;
}

export interface Category {
  id: number;
  title: string;
  topics: Topic[];
}

export interface SearchQuery {
  searchTerm: string;
  filters: SearchFilters;
  pageIndex: number;
  pageSize: number;
}

export interface SearchFilters {
  topicId: number;
  categoryId: number;
  createdWithinDays: number;
  updatedWithinDays: number;
}

export interface APIQueryCollection {
  getAll: Function;
  getById: Function;
  upsert: Function;
  delete: Function;
}

export interface SimpleAPIClient {
  content: APIQueryCollection;
  topics: APIQueryCollection;
  categories: APIQueryCollection;
}
