pipeline {
    agent any

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
	    stage('Building: API') {
            steps{
                sh "echo '[API] Building...'"
                sh "dotnet build cAppsule.sln"
            }
            post {
                success {
                    sh "echo 'API built successfully'"
                }
            }
        }
        stage("Reset containers"){
            steps{
                sh "docker compose down"
                sh "docker compose up -d --build --force-recreate --renew-anon-volumes"
            }
        }
    }
}
