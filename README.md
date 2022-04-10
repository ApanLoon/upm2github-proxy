# upm2github-proxy
Proxy between Unity Package Manager and GitHub Packages

There are several issues with trying to make Unity understand packages hosted on npm.pkg.github.com:
1. The github package repository does not implement the standard /-v1/search api
2. The Unity Package Manager (UPM) does not accept github scoping, i.e. the "@user/" or "@organization/" prefix in package names
3. The Unity Package Manager doesn't, as far as I know, handle authentication in a way that works with github

upm2github-proxy attempts to alleviate these issues.

So far, the proxy has the following features:
1. Uses the github API to leverage the search api, although the actual search text is not yet used - it returns all packages under the user scope and Unity does list these in the package manager window
2. Converts formats in the returned json documents as there are some differences between upm, "npm standard" and "npm github"
3. Re-directs package downloads so that credentials can be sent when downloading packages. This is currently hard-coded to http://localhost:5080
4. Keeps npm/github access tokens in a plain text dictionary named "authdata.json" with usernames as keys and the plain token as values

