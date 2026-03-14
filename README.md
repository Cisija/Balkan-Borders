# Balkan Borders

Unity project for the game.

## Unity version

Open this project with Unity `2019.4.41f2`.

## What belongs in git

Commit these folders:

- `Assets/`
- `Packages/`
- `ProjectSettings/`

Also keep all Unity `.meta` files tracked.

Do not commit generated files and local editor state such as:

- `Library/`
- `Temp/`
- `Logs/`
- `obj/`
- `.vs/`
- `.vscode/`
- `*.sln`
- `*.csproj`
- build output folders like `Build/` or `Builds/`

## Getting the project to collaborators

Do not send only the C# files. Unity projects need the full project structure, including scenes, prefabs, settings, packages, and `.meta` files.

Recommended workflow:

1. Create a private GitHub repository.
2. Push this whole Unity project to that repository.
3. Add friends as collaborators on the private repository.
4. Have each person clone the repo locally.
5. Open the cloned folder in Unity Hub with version `2019.4.41f2`.
6. Let Unity rebuild `Library/` on first open.

## Suggested collaboration rules

Safest option:

- Keep `main` protected.
- Friends work in branches.
- Changes come in through pull requests.

Simpler option:

- Give trusted friends write access.
- They can push branches directly.
- You still review and merge into `main`.

## First push checklist

1. Initialize git in this folder.
2. Create an initial commit.
3. Create an empty private repo on GitHub.
4. Add the remote.
5. Push `main`.

Example commands:

```bash
git init
git add .
git commit -m "Initial Unity project import"
git branch -M main
git remote add origin <your-private-repo-url>
git push -u origin main
```
