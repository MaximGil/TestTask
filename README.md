# TestTask
Проект написан с использованием Playwright. Была использована библиотека Playwright.NUnit. Были использован Page Object Model.

Для запуска тестов локально в headless mode нужно прописать команду в папке с решением : dotnet test -e "HEAEDED=0"

Для запуска тестов локально в различных браузерах нужно прописать команду в папке с решением : dotnet test -e "BROWSER=chrome" (пример для хрома)

Для запуска тестов локально в различных браузерах и в headless mode нужно прописать команду в папке с решением : dotnet test -e "BROWSER=chrome" -e "HEADED=0" 
 (пример для хрома)
