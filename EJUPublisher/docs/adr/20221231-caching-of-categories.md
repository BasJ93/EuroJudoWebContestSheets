# Caching of categories

- Status: accepted
- Deciders: Bas
- Date: 2022-12-31
- Tags: uploading, results

Technical Story: How to keep track of which contest goes with which category on the server.

## Context and Problem Statement

The data coming from EuroJudo's ShowFights does not contain a complete category, insted it has a category short and a weight class. The web server may contain multiple matching categories, and therefor needs to be told which category it should use. The client needs to make this match.

## Decision Outcome

The service layer for the tournaments in the uploader caches the correlation between the EuroJudo category and the id required for the webserver. When a category is found that's not in the cache, the client requests the id from the webserver. Because the client does not know the size of the category, it can not create it on it's own.
