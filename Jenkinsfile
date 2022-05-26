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
                sh "docker compose --env-file ./config/Test.env build api"
            }
            post {
                success {
                    sh "echo 'API built successfully'"
                }
            }
        }

        stage('Test backend'){
            steps {
                sh "dotnet test"
            }
        }

        stage("Reset containers"){
            steps{
                script { 
                    try {
                        sh "docker compose --env-file ./config/Test.env down"
                    }
                    finally {}
                }
            }
        }

        stage('Deploy containers'){
            steps {
                sh "docker compose --env-file ./config/Test.env up -d"
            }
        }

        stage('Push image to reg') {
            steps {
                sh "docker compose --env-file ./config/Test.env push"
            }
        }
    }
}
