/*
    SimpleCMS API Integration Module
*/

export default {
    content: {
        search: async (query) => {
            console.log("searching for content hehe");
        },
        getById: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        upsert: async (topic) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        delete: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        }
    },

    topics: {
        getById: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        getAll: async () => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        upsert: async (topic) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        delete: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        }
    },

    categories: {
        getById: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        getAll: async () => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        upsert: async (topic) => {
            console.log("NOT YET IMPLEMENTED hehe");
        },
        delete: async (id) => {
            console.log("NOT YET IMPLEMENTED hehe");
        }
    }
}