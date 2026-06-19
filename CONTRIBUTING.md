# Contributing to PetFriends

Thank you for contributing to PetFriends.

This document defines the development workflow and repository conventions used in the project.

## Project management

Jira is the source of truth for project planning.

Every code change must be associated with a Jira work item, identified by a key such as:

```text
PF-27
```

GitHub Issues are not used for project planning to avoid duplicating work between GitHub and Jira.

## Development workflow

The project follows GitHub Flow and uses the following Jira workflow:

```text
To Do
  ↓
In Progress
  ↓
Done
```

A work item remains `In Progress` during implementation, testing and Pull Request review.

The development process is:

1. Select and assign a Jira work item.
2. Move the work item to `In Progress`.
3. Switch to `main` and pull the latest changes.
4. Create a branch from the updated `main`.
5. Implement and test the change.
6. Commit and push the changes.
7. Open a Pull Request targeting `main`.
8. Review the changed files and validate the automated checks.
9. Squash and merge the Pull Request into `main`.
10. Confirm that the CI workflow passes on `main`.
11. Move the Jira work item to `Done`.
12. Delete the completed local branch.

Direct development on `main` is not allowed.

## Branch naming

Branches must follow this format:

```text
<type>/<jira-key>-<short-description>
```

Allowed branch types:

* `feature`: new functionality;
* `fix`: bug correction;
* `chore`: project maintenance or configuration;
* `docs`: documentation changes;
* `refactor`: internal code restructuring;
* `test`: test-related work.

Examples:

```text
feature/PF-27-create-animal-report
fix/PF-42-report-date-validation
chore/PF-14-repository-standards
docs/PF-63-update-api-documentation
```

Use lowercase characters and hyphens. Do not use spaces or accented characters.

## Commit messages

Commit messages follow the Conventional Commits format:

```text
<type>(<jira-key>): <description>
```

Allowed commit types:

* `feat`: new functionality;
* `fix`: bug correction;
* `docs`: documentation;
* `test`: tests;
* `refactor`: code restructuring without changing behaviour;
* `chore`: maintenance and configuration;
* `ci`: continuous integration;
* `build`: build system or dependency changes;
* `perf`: performance improvement.

Examples:

```text
feat(PF-27): add animal report entity
fix(PF-42): reject future occurrence dates
docs(PF-14): add repository contribution guidelines
test(PF-51): add report creation integration tests
ci(PF-16): add build and test workflow
```

Commit descriptions must:

* be written in English;
* use the imperative form;
* start with a lowercase letter;
* not end with a period;
* describe one logical change.

Avoid messages such as:

```text
changes
fix
test
final version
now it works
```

## Pull Requests

Pull Request titles must follow the same convention as commit messages:

```text
docs(PF-14): add repository standards and conventions
```

Every Pull Request must:

* reference the Jira work item;
* explain what was changed;
* include testing instructions;
* have a limited and coherent scope;
* pass the build and automated tests;
* contain no secrets or credentials;
* update documentation when applicable.

Large Pull Requests should be divided into smaller independent changes.

## Code conventions

Code, identifiers, technical documentation and commit messages must be written in English.

User-facing application content may be translated into other languages.

C# code should follow these rules:

* enable nullable reference types;
* use file-scoped namespaces;
* use PascalCase for types, properties and public members;
* use camelCase for local variables and parameters;
* prefix interfaces with `I`;
* suffix asynchronous methods with `Async`;
* keep one principal public type per file;
* prefer dependency injection over manually creating dependencies;
* do not place business rules in controllers;
* do not suppress compiler warnings without justification.

Formatting rules defined in `.editorconfig` must be respected.

## Sensitive information

Never commit:

* passwords;
* connection strings containing credentials;
* API keys;
* access tokens;
* private certificates;
* `.env` files;
* local User Secrets;
* production configuration.

Use `.env.example` to document required environment variables without including real values.

## Before opening a Pull Request

From the repository root, confirm that:

```text
dotnet tool restore
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --configuration Release --no-build
```

complete successfully.

Also confirm that:

* the branch was created from an updated `main`;
* all acceptance criteria have been satisfied;
* applicable tests have been added or updated;
* documentation reflects any relevant changes;
* no local configuration or sensitive information is included;
* the Pull Request has a limited and coherent scope.

## Definition of Done

A work item is considered complete when:

* all acceptance criteria are satisfied;
* the solution builds successfully in `Release`;
* applicable tests have been added or updated;
* all automated tests pass;
* the GitHub Actions CI workflow passes;
* no secrets or credentials were committed;
* the code was reviewed through a Pull Request;
* documentation was updated when necessary;
* the Pull Request was squash-merged into `main`;
* the completed branch was removed;
* the Jira work item was moved to `Done`.
