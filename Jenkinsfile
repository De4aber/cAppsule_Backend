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
        stage("Deploy"){
                    steps{
                        sh "docker compose up -d"
                    }
                }
    }
}
