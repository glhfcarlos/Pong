using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int secondsLeft;
    public Transform ballPosition;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text timerText;
    public GameObject ballPrefab;

    private PaddleUnit player1Paddle;
    private PaddleUnit player2Paddle;
    private Ball ball;

    public int resetPause;

    private bool runGame;
    private bool paused;

    void Awake(){
        runGame = false;
        paused = false;
    }

    void Update(){
        if (secondsLeft <= 0){
            EndGame();
        }else if (runGame && !paused){
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown(){
        // stops update() from running this
        paused = true;
        yield return new WaitForSeconds(1);
        // display time left
        timerText.text = secondsLeft.ToString();
        // decrement time left
        secondsLeft--;
        // enables update to run this again
        paused = false;
    }

    // allows the player manager to add the scripts when players join
    public void TrackPlayer1(PaddleUnit paddle){
        player1Paddle = paddle;
    }
    public void TrackPlayer2(PaddleUnit paddle){
        player2Paddle = paddle;
        // spawns ball only when players have joined
        SpawnBall();
        // start the timer
        runGame = true;
    }
    void SpawnBall(){
        GameObject ballGO = Instantiate(ballPrefab, ballPosition.position, Quaternion.identity);
        ball = ballGO.GetComponent<Ball>();
    }

    public void Player1Scores()
    {
        player1Paddle.AddToScore();

        this.player1ScoreText.text = player1Paddle.score.ToString();
        StartCoroutine(ResetRound());
    }

    public void Player2Scores()
    {
        player2Paddle.AddToScore();
        
        this.player2ScoreText.text = player2Paddle.score.ToString();
        StartCoroutine(ResetRound());
    }

    // FIXME: add code to deal with broken ball

    /*
        This should change the scene to the "GameOver" scene and display who won.
    */
    public void EndGame(){
         /*
            FIXME: 
                [ ] This should change the scene to the "GameOver" scene and display who won.
                [ ] There should be options to restart or return to start screen.
                [v] Player input maps should be changed to UI for this.
                [v] stop ball movement
        */
        // destroy the ball
        ball.StopMovement();
        // switch player action maps to UI
        player1Paddle.ChangeInputMap("UI");
        player2Paddle.ChangeInputMap("UI");

        // display who won
        if (player1Paddle.score > player2Paddle.score){
            timerText.text = "Wizard Wins";
        }else if (player2Paddle.score > player1Paddle.score){
            timerText.text = "Thief Wins";
        }else{
            timerText.text = "Tie";
        }

        // disable timer
        runGame = false;
    }

    IEnumerator ResetRound()
    {
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        // add pause here to give players time to get their bearings
        yield return new WaitForSeconds(resetPause);
        this.ball.AddStartingForce();
    }
}
