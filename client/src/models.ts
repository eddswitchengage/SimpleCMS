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
}

export interface SearchFilters {
  topicId: number;
  categoryId: number;
  createdWithinDays: number;
  updatedWithinDays: number;
}
