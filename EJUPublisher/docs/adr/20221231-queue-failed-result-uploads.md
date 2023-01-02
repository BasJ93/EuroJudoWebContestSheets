# Queue failed result uploads

- Status: accepted
- Deciders: Bas
- Date: 2022-12-32
- Tags: uploads, failed, queue

Technical Story: What to do when the upload of a result fails.

## Context and Problem Statement

It may happen that the upload of a result fails, for example because the network connection was interrupted or because the category is not known on the web server. What should be done with these results?

## Decision Drivers

- Having the complete results online is nice :)
- Results are delivered in a "send and forget" style by EuroJudo.

## Considered Options

- [option 1]
- [option 2]
- [option 3]
- … <!-- numbers of options can vary -->

## Decision Outcome

If the upload of a result fails, the result should be written to a queue so that it can be retried at a later moment. The retry should use a backoff principle where the time between retries becomes bigger every time it needs to be retried. In case the application may be shut down, the queue should also be written to a file on disk, with all required properties needed to retry after a restart.
